# SovTechTest
#Hosting API.SovTest( ASP.NET Core 3.1 Web API) as Windows service.

#First, you have to download the code from the repository to your localhost/cloud. To do that, First make sure you that you have git installed on your machine then you can either directly download the zip file and extract it to the location of your choice or you you can open a Cli terminal (e.g cmd,powershell, gitbash...) ideally from a folder that is esasily accessible , once you have your cli terminal opened run the following git command:
  git clone https://github.com/SaneleMhlakaza/API.SovTechTest.git
#Once git clone is complete, run cd API.SovTechTest in your cli terminal. Once that is done , you have successfully downloaded API.SovTechTest code.
#Next step is to publish ("Build") the application. So to do that run the following command , ideally using cmd from windows, publish
dotnet publish
#Go to bin\Release\netcoreapp3.1 and you will find the publish folder which contains our published dlls.
#To create Windows service open a command prompt in administrator mode and use the below command:
sc create <name of service you want to create> binPath= <path of executable of your app> --service
  e.g. sc create api.sovtechser binPath= "C:\Users\Sanele\source\repos\SovTechTest\bin\Release\netcoreapp3.1\publish\API.SovTechTest.exe --service"
  #And that's it! your service is created.
  ![image](https://user-images.githubusercontent.com/98617432/151690248-851badab-7a3f-47a2-b7fe-5b70878d75ca.png)
#Right-click on service and click on start. So our Web API is running on URL http://localhost:5000. 
