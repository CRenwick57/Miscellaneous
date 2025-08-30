@echo off
setlocal
set /p Projectname=Name your project: 

call npm create vite@latest "%Projectname%" -- --template react

cd %Projectname%

call npm install

call npm run dev

pause
endlocal