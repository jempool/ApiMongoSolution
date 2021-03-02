FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy all project and build
COPY . ./
RUN dotnet restore
RUN dotnet publish --runtime osx.10.11-x64 --self-contained false -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Api.dll"]