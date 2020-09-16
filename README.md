# HorseStrap

![alternativetext](https://horsestrap.com/images/nily.svg)

Requirements are

- .NET Core 2.x
- NodeJS(>=8)

To download .NET Core, grab the runtime

Mac - https://www.microsoft.com/net/download/macos
Windows - https://www.microsoft.com/net/download/windows/build

Install and confirm you have access to it globally by running `dotnet --version`
You shoudl be running 2.1 or greater.

As long as Node is installed as well, you shoudl be good to roll.

CD into the project folder and run `dotnet run` which will start the Kestel web server and automatically open the site in your browser.

The site is available at at localhost:3000 through BrowserSync which is proxying the .NET Core app from https://localhost:5001. Instructions on how to tweak these ports coming soon.

Styles are located at ~/assets/sass/ and updates to them will be automatically be injected via WebPack. Changes to any Razor(.cshtml) files will trigger a browser refresh through BrowerSync. This will result in far fewer manual browser refreshing.