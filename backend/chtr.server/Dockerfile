FROM mcr.microsoft.com/dotnet/core/sdk:2.1 as build-image

WORKDIR /home/app
 
COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
 
RUN dotnet restore

COPY . .

RUN dotnet publish ./chtr.server/chtr.server.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1

WORKDIR /publish

COPY --from=build-image /publish .

ENTRYPOINT ["dotnet", "chtr.server.dll"]