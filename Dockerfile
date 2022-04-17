FROM ubuntu:20.04
RUN apt-get update && apt-get install -y git wget libssl-dev
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb; \
    dpkg -i packages-microsoft-prod.deb; \
    rm packages-microsoft-prod.deb
RUN apt-get update && DEBIAN_FRONTEND='noninteractive' apt-get install -y apt-transport-https dotnet-sdk-5.0
RUN git clone https://github.com/developer-onizuka/redisCache-MongoDB.git && cd redisCache-MongoDB/Employee; \
    dotnet publish -c release -r linux-x64 --self-contained
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
ENV ASPNETCORE_URLS="https://*:5001;http://*:5000"
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https
ENTRYPOINT /redisCache-MongoDB/Employee/bin/release/net5.0/linux-x64/Employee
