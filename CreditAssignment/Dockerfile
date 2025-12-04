# === BUILD ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# === RUNTIME ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Render ustawia PORT, wiêc musimy s³uchaæ na tym porcie
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT
EXPOSE 5000

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CreditAssignment.dll"]
