FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /CollectorCommands
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build  
COPY . /src
WORKDIR /src
RUN ls

RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -r linux-x64 --no-dependencies --self-contained true -p:DebugType=None -p:DebugSymbols=false -p:GenerateDocumentationFile=False -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN mkdir /keys

EXPOSE 80

CMD ["dotnet", "CollectorCommands.dll"]