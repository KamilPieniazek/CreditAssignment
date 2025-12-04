# =========================
# BUILD IMAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# =========================
# RUNTIME IMAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Forward Render environment variables into container
ENV PORT=${PORT}
ENV DATABASE_URL=${DATABASE_URL}
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

COPY --from=build /app/publish .
EXPOSE 5000

ENTRYPOINT ["dotnet", "CreditAssignment.dll"]
