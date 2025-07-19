# Use official PostgreSQL image
FROM postgres:16

# Set environment variables (these can also be set in docker-compose.yml)
ENV POSTGRES_DB=CatalogDb
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=postgres
FROM build AS catalogapi
# Optionally copy initialization scripts
# These will be run on container startup

