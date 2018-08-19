FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY src/QuoteService/QuoteService.csproj src/QuoteService/
RUN dotnet restore src/QuoteService/QuoteService.csproj

COPY . .
WORKDIR /app/src/QuoteService
RUN dotnet publish QuoteService.csproj -c Release -o /out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /out .
ENV VERSION=1.0.18
ENTRYPOINT ["dotnet", "QuoteService.dll"]
