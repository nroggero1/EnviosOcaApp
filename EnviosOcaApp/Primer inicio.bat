@echo off
chcp 65001 >nul
title Configuración Inicial - Envíos OCA
color 1F

echo ========================================================
echo       INSTALACIÓN Y CONFIGURACIÓN INICIAL
echo                SISTEMA ENVÍOS OCA
echo             Grupo Sancor Seguros
echo ========================================================
echo.
echo Copiando archivos de la aplicación a su equipo para
echo garantizar el máximo rendimiento y arranque instantáneo...
echo.

set "ORIGEN=\\ss1039\Sectores\Centro Emisor\Automatizaciones\OCA\OCA\App"
if not exist "%ORIGEN%" (
    if exist "%~dp0App" set "ORIGEN=%~dp0App"
)

set "DESTINO=%USERPROFILE%\Documents\EnviosOCA"

if not exist "%DESTINO%" mkdir "%DESTINO%"

echo [1/3] Copiando archivos del sistema...
robocopy "%ORIGEN%" "%DESTINO%" /MIR /R:2 /W:1 /NP /NFL /NDL >nul
if %ERRORLEVEL% GEQ 8 (
    echo.
    echo ERROR: No se pudieron copiar todos los archivos desde la red.
    echo Por favor verifique la conexión con el servidor \\ss1039.
    pause
    exit /b %ERRORLEVEL%
)

echo [2/3] Creando acceso directo en el Escritorio...
set "VBS_SCRIPT=%TEMP%\crear_acceso_oca_%RANDOM%.vbs"
(
echo Set oWS = WScript.CreateObject("WScript.Shell"^)
echo sLinkFile = oWS.SpecialFolders("Desktop"^) ^& "\Envíos OCA.lnk"
echo Set oLink = oWS.CreateShortcut(sLinkFile^)
echo oLink.TargetPath = "%DESTINO%\EnviosOcaApp.exe"
echo oLink.WorkingDirectory = "%DESTINO%"
echo oLink.Description = "Sistema de Gestión de Envíos OCA - Grupo Sancor Seguros"
echo oLink.IconLocation = "%DESTINO%\EnviosOcaApp.exe, 0"
echo oLink.Save
) > "%VBS_SCRIPT%"

cscript //nologo "%VBS_SCRIPT%"
del "%VBS_SCRIPT%" >nul 2>&1

echo [3/3] ¡Configuración completada con éxito!
echo.
echo ========================================================
echo   Se ha creado el acceso directo 'Envíos OCA' en su Escritorio.
echo   Iniciando la aplicación localmente...
echo ========================================================
echo.

start "" "%DESTINO%\EnviosOcaApp.exe"

timeout /t 3 >nul
exit
