all:
	dotnet sonarscanner begin /k:"CosmeticSalon" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_d154dae9e7f72610b6981ae25cb3e216868026a1"
	dotnet build --no-incremental
	dotnet-coverage collect 'dotnet test' -f xml  -o 'coverage.xml'
	dotnet sonarscanner end /d:sonar.token="sqp_d154dae9e7f72610b6981ae25cb3e216868026a1"
	dotnet build-server shutdown