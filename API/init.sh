#!/bin/bash
cd /api/;
dotnet restore;
cd /api/WebAPI;
dotnet watch run;