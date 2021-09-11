# TictactToe Challenge

Project challenge for Dunnhumby 


2. Install dependencies with the command:

  ```bash
  dotnet restore 
  ```

3. Build the project with the command: 

  ```bash
  dotnet build
  ```

1. Run the project you got two options:

  ```bash
  dotnet run --project TicTacToe
  ```

## For running tests

```bash
dotnet test
```

## For Test coverage
```bash
dotnet test --collect "Code Coverage" --results-directory .
```

### To Preview the code coverage

1. Install reportgenerator
  
    ```bash
    dotnet tool install -g dotnet-reportgenerator-globaltool
    ```

2. Run this command
   
   ```bash
   reportgenerator -reports:".\**\*.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
   ```
