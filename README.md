# TictactToe Challenge

Project challenge


1. Install dependencies with the command:

  ```bash
  dotnet restore 
  ```

2. Build the project with the command: 

  ```bash
  dotnet build
  ```

3. Run the project:

  ```bash
  dotnet run --project TicTacToe
  ```

## For running tests

```bash
dotnet test
```

## For Test coverage
```bash
dotnet test --collect:"XPlat Code Coverage"
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
