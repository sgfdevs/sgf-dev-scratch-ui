# Springfield Devs Website - Scratch UI

![SGF Devs Banner](https://mykebates.blob.core.windows.net/towk/SGF-DEVS-Twitter-BG.png)

This repo will be used to further the progress of the front-end development process for the official Springfield Devs site (https://sgf.dev)
Eventually this work will be migrated into either a SPA setup or directly into the .NET Core project where the rest of the back-end work is being developed.

Requirements are

- .NET Core 3.x
- NodeJS(>=8)

To download .NET Core, grab the latest stable SDK: https://dotnet.microsoft.com/download

Install and confirm you have access to it globally by running `dotnet --version`
You should be running 3.1 or greater.

Lastly, as long as Node is installed as well, you should be good to roll.

CD into the project folder and run `npm install`. 

After that you're ready to run `dotnet run`, which will start the Kestrel web server and automatically open the site in your browser.

If you get an error complaining about an invalid certificate or SSL errors run the following commands on Windows or Mac
`dotnet dev-certs https`
`dotnet dev-certs https --trust`


The site is available at at localhost:3000 through BrowserSync which is proxying the .NET Core app from localhost:5000

Styles are located at ~/assets/sass/ and updates to them will be automatically be injected via WebPack. Changes to any Razor(.cshtml) files will trigger a browser refresh through BrowerSync.

## Design Assets
The site design was done in [Sketch](https://www.sketch.com/) - which only runs on macOS and does require a software license. 

The Sketch file can be downloaded [here](https://sgfdev.sharepoint.com/:u:/g/EY8ZF0FgmUJIoopvionoPeIBFtv-IOQvXdF0qzs5OUAF-w?e=TThRh9)

The design can still be accessed and(to a certain extent 'inspected') with Invision. You will need a free [Invision](https://www.invisionapp.com/) account in order to use the [Inspect](https://www.invisionapp.com/feature/inspect/) feature. Otherwise you can simply browse the design without an acocunt. If logged in with an account, click the "Inspect" icon in the lower-right and request access.

Invision document is located [here](https://invis.io/V6XI7764NFA)
