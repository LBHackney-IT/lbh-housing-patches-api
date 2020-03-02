FROM microsoft/dotnet:2.2-sdk

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./lbh-housing-patches-api.sln ./
COPY ./lbh-housing-patches-api/lbh-housing-patches-api.csproj ./lbh-housing-patches-api/
COPY ./lbh-housing-patches-api.Tests/lbh-housing-patches-api.Tests.csproj ./lbh-housing-patches-api.Tests/

RUN dotnet restore ./lbh-housing-patches-api/lbh-housing-patches-api.csproj
RUN dotnet restore ./lbh-housing-patches-api.Tests/lbh-housing-patches-api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out lbh-housing-patches-api.Tests/lbh-housing-patches-api.Tests.csproj

CMD dotnet test
