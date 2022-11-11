#!/bin/sh

apt update
apt install -y postgresql-client
dotnet tool install --global dotnet-ef --version 6.0.11