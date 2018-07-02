# Vertmarkets
Magazine Store : This application identifies all subscribers that are subscribed to at least one magazine in each category.

### Building and Running

#### Method 1
-Prerequisite [Docker](https://www.docker.com/community-edition#/download) and [Git](https://git-scm.com/downloads).
1. Clone the reposiory to your local folder
`git clone https://github.com/getanish/Vertmarkets.git`
2. Navigate to the Vertmarkets folder
3. Build the docker file
`docker build -t magazinestore .`
4. Run your application
`docker run --rm magazinestore`

#### Method 2
-Prerequisite [.Net Core 2.1 runtime](https://www.microsoft.com/net/download/windows)
1. Download the zip file 
`https://github.com/getanish/Vertmarkets/archive/master.zip`
2. Unzip the contents
3. Navigate to the **Vertmarkets** project folder.
 eg **Vertmarkets-master\Vertmarkets**
4. Restore the dependencies
`dotnet restore`
5. Build and run the code
`dotnet run`