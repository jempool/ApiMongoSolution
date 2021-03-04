# FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
# WORKDIR /app

# # Copy all project and build
# COPY . ./
# RUN dotnet restore
# RUN dotnet publish --runtime osx.10.11-x64 --self-contained false -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:5.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "Api.dll"]



  FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY out/ App/
  WORKDIR /App
  EXPOSE 5000/tcp
  ENTRYPOINT ["dotnet", "Api.dll"]

# docker build -f multistage.webapi.dockerfile -t aspnetapp .
# docker run -d -p 8080:80 --name mydotnetapp aspnetapp
# docker run --rm -p 5000:80 --name mydotnetapp aspnetapp

# docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" mydotnetapp

