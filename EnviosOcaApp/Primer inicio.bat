@echo off
title Configuracion Inicial - Envios OCA
color 1F

echo ========================================================
echo       INSTALACION Y CONFIGURACION INICIAL
echo                SISTEMA ENVIOS OCA
echo             Grupo Sancor Seguros
echo ========================================================
echo.
echo Preparando archivos de la aplicacion en su equipo...
echo Esto garantiza el maximo rendimiento y arranque instantaneo.
echo.

:: 1. Detectar carpeta de origen
set "ORIGEN="

if exist "%~dp0OCA\App\EnviosOcaApp.exe" (
    set "ORIGEN=%~dp0OCA\App"
) else if exist "%~dp0App\EnviosOcaApp.exe" (
    set "ORIGEN=%~dp0App"
) else if exist "%OneDriveCommercial%\OCA\OCA\App\EnviosOcaApp.exe" (
    set "ORIGEN=%OneDriveCommercial%\OCA\OCA\App"
) else if exist "%OneDrive%\OCA\OCA\App\EnviosOcaApp.exe" (
    set "ORIGEN=%OneDrive%\OCA\OCA\App"
) else if exist "%USERPROFILE%\OneDrive - Grupo Sancor Seguros\OCA\OCA\App\EnviosOcaApp.exe" (
    set "ORIGEN=%USERPROFILE%\OneDrive - Grupo Sancor Seguros\OCA\OCA\App"
)

if "%ORIGEN%"=="" (
    echo.
    echo ========================================================
    echo ERROR: No se encontro la carpeta con los archivos de la app.
    echo.
    echo Asegurese de haber agregado el acceso directo a OneDrive:
    echo  1. Abra el enlace compartido de OneDrive en el navegador.
    echo  2. Haga clic en 'Agregar acceso directo a Mis archivos'.
    echo ========================================================
    echo.
    pause
    exit /b 1
)

:: 2. Detectar carpeta destino en Documentos
set "DESTINO=%USERPROFILE%\Documents\EnviosOCA"
if not exist "%USERPROFILE%\Documents" (
    if exist "%USERPROFILE%\Documentos" (
        set "DESTINO=%USERPROFILE%\Documentos\EnviosOCA"
    )
)

if not exist "%DESTINO%" mkdir "%DESTINO%"

echo [1/3] Copiando archivos del sistema a su carpeta Documentos...
echo Origen:  %ORIGEN%
echo Destino: %DESTINO%
echo.

robocopy "%ORIGEN%" "%DESTINO%" /MIR /R:2 /W:1 /NP /NFL /NDL >nul
if %ERRORLEVEL% GEQ 8 (
    echo ERROR: Ocurrio un problema al copiar los archivos locales.
    echo Codigo de error: %ERRORLEVEL%
    pause
    exit /b %ERRORLEVEL%
)

if not exist "%DESTINO%\EnviosOcaApp.exe" (
    echo ERROR: No se encontro EnviosOcaApp.exe en %DESTINO%
    pause
    exit /b 1
)

echo [2/3] Creando acceso directo en el Escritorio...
set "VBS_FILE=%TEMP%\crear_acceso_oca.vbs"
echo Set oWS = WScript.CreateObject("WScript.Shell") > "%VBS_FILE%"
echo sLink = oWS.SpecialFolders("Desktop") ^& "\Envios OCA.lnk" >> "%VBS_FILE%"
echo Set oLink = oWS.CreateShortcut(sLink) >> "%VBS_FILE%"
echo oLink.TargetPath = "%DESTINO%\EnviosOcaApp.exe" >> "%VBS_FILE%"
echo oLink.WorkingDirectory = "%DESTINO%" >> "%VBS_FILE%"
echo oLink.Description = "Sistema de Envios OCA - Grupo Sancor Seguros" >> "%VBS_FILE%"
echo oLink.Save >> "%VBS_FILE%"

cscript //nologo "%VBS_FILE%"
if exist "%VBS_FILE%" del "%VBS_FILE%" >nul 2>&1

echo [3/3] Configuracion completada con exito!
echo.
echo ========================================================
echo   Acceso directo 'Envios OCA' creado en su Escritorio.
echo   Iniciando la aplicacion...
echo ========================================================
echo.

start "" "%DESTINO%\EnviosOcaApp.exe"

timeout /t 3 >nul
exit
