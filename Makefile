.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose run lbh-housing-patches-api dotnet build

.PHONY: serve
serve:
	docker-compose up lbh-housing-patches-api

.PHONY: shell
shell:
	docker-compose run lbh-housing-patches-api bash

.PHONY: test
test:
	docker-compose build lbh-housing-patches-api-test && docker-compose up lbh-housing-patches-api-test
