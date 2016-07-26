#!/bin/bash
cd /api/;
dotnet restore;
cd /api/src/WebAPI;
dotnet ef database update -e stage;
dotnet watch run;