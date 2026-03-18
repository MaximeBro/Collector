# Collector

```bash
# Code Coverage result (CLI only)
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[*]Microsoft.AspNetCore.OpenApi.Generated.*" /p:ExcludeByFile="**/Migrations/*.cs" /p:ExcludeByAtribute="GeneratedCodeAttribute" /p:ExcludeByAttribute="CompilerGeneratedAttribute" /p:ExcludeByFile="**/*.generated.cs"
```

```bash
# Code coverage
dotnet test --collect:"XPlat Code Coverage"

# Report generator
reportgenerator -reports:.\coverage.cobertura.xml -reportTypes:Html -targetDir:.
```