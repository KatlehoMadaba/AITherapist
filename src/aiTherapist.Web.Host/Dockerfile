FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/aiTherapist.Web.Host/aiTherapist.Web.Host.csproj", "src/aiTherapist.Web.Host/"]
COPY ["src/aiTherapist.Web.Core/aiTherapist.Web.Core.csproj", "src/aiTherapist.Web.Core/"]
COPY ["src/aiTherapist.Application/aiTherapist.Application.csproj", "src/aiTherapist.Application/"]
COPY ["src/aiTherapist.Core/aiTherapist.Core.csproj", "src/aiTherapist.Core/"]
COPY ["src/aiTherapist.EntityFrameworkCore/aiTherapist.EntityFrameworkCore.csproj", "src/aiTherapist.EntityFrameworkCore/"]
WORKDIR "/src/src/aiTherapist.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/aiTherapist.Web.Host", "src/aiTherapist.Web.Host"]
COPY ["src/aiTherapist.Web.Core", "src/aiTherapist.Web.Core"]
COPY ["src/aiTherapist.Application", "src/aiTherapist.Application"]
COPY ["src/aiTherapist.Core", "src/aiTherapist.Core"]
COPY ["src/aiTherapist.EntityFrameworkCore", "src/aiTherapist.EntityFrameworkCore"]
WORKDIR "/src/src/aiTherapist.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "aiTherapist.Web.Host.dll"]
