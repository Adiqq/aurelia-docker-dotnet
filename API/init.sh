#!/bin/bash
cd /api/;
dotnet restore;
cd /api/src/WebAPI;
dotnet watch run;