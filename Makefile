.PHONY: up
up:
	docker-compose up -d

.PHONY: down
down:
	docker-compose down

.PHONY: createmigration
create_migration:
	dotnet ef migrations add ThreeLayerArch -s ./src/ThreeLayerArch.API -p ./src/ThreeLayerArch.Data

.PHONY: migrate
migrate:
	 dotnet ef database update -s ./src/ThreeLayerArch.API -p ./src/ThreeLayerArch.Data
