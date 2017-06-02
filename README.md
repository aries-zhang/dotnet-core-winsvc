# dotnet-core-winsvc
A example of how to compose a windows service in dotnet core.


Since there is no officially provided solution to run dotnet core as windows service, there are the following ways innovated by the community.

1. Run the console application in docker, you can see the disscussion [here](https://github.com/aspnet/Home/issues/1845).

2. Bridging, which I would like to call so, is more usual. There are discussions on [StackOverFlow](https://stackoverflow.com/questions/41014513/windows-service-with-net-core), and the representative libraries are [DotNetCore.WindowsService](https://github.com/PeterKottas/DotNetCore.WindowsService) and 
[DasMulli.Win32.ServiceUtils](https://github.com/dasMulli/dotnet-win32-service). You can easily create a windows service app following their documents, so I won't talk talk too much about this way here.


3. Wrapping is a less common way. It wraps dotnet standard library in a windows service runs on .Net Framework. [This article](https://stackify.com/creating-net-core-windows-services/) introduces how to do this and I realized it in this repository. You can download and see how wrap it all together.

    In this way, you have to pay attention to compatibility of dotnet standard versions, or you will not be able to compile successfully. See the compatibility table here: [https://github.com/dotnet/standard/blob/master/docs/versions.md](https://github.com/dotnet/standard/blob/master/docs/versions.md)

