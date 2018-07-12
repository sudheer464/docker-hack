FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY myapp/*.csproj ./myapp/
RUN dotnet restore

# copy everything else and build app
COPY myapp/. ./myapp/
WORKDIR /app/myapp
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/myapp/out ./
ENTRYPOINT ["dotnet", "myapp.dll"]


#	docker build -t rahulell/aspnetapp .
#	docker run -it --rm -d -p 8000:80 rahulell/aspnetapp
#	http://localhost:8000/