FROM filiosoft/dotnetcore-nodejs
MAINTAINER Alexander Trashkov <alex@trashkov.ru>

COPY . /project

#Building frontend
WORKDIR /project/AdvertExplorer.Client
RUN rm -rf node_modules
RUN apt-get install libpng12-0
RUN npm update
RUN npm run build

#Building backend
WORKDIR /project/AdvertExplorer.Server/src/AdvertExplorer.Server.Web
RUN dotnet restore
RUN dotnet build

#Copy frontend into wwwroot folder
RUN cp -a \
	/project/AdvertExplorer.Client/www/. \
	/project/AdvertExplorer.Server/src/AdvertExplorer.Server.Web/wwwroot/

#Configuration
RUN mkdir /data
VOLUME /data
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT dotnet run