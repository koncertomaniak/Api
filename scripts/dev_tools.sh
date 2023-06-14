#!/bin/sh

sudo apt-get update
sudo apt-get install -y postgresql-client
dotnet tool install --global dotnet-ef --version 6.0.11