FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build-env

RUN apt update && apt install -y tzdata && apt clean && rm -rf /var/lib/apt/lists/*
ENV TZ Asia/Tokyo

WORKDIR /app

# CIからのmigration用にgcloud proxyを用意しておく
RUN wget https://dl.google.com/cloudsql/cloud_sql_proxy.linux.amd64 -O /usr/local/bin/cloud_sql_proxy && \
    chmod +x /usr/local/bin/cloud_sql_proxy

# mysql5.7とdotnet-ef 3.0の組み合わせだと、接続時に
# Interop+OpenSsl+SslException: SSL Handshake failed with OpenSSL error - SSL_ERROR_SSL.
# のエラーが発生するのでopensslのconfを書き換えて対応する
RUN sed -i "s|TLSv1.2|TLSv1.0|g" /etc/ssl/openssl.cnf
RUN sed -i "s|DEFAULT@SECLEVEL=2|DEFAULT@SECLEVEL=1|g" /etc/ssl/openssl.cnf

RUN dotnet tool install --global dotnet-ef --version 5.0.7