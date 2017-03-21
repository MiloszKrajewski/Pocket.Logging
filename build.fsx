#r ".fake/FakeLib.dll"

open Fake

let build = MSBuild "" "Build" [ ("Configuration", "Release"); ("Platform", "Any CPU") ] >> ignore
let shell exe args = 
    sprintf "> %s %s" exe args |> trace
    match Shell.Exec (exe, args) with 
    | 0 -> () 
    | e -> failwithf "Command failed with error code: %d" e

Target "Build" (fun _ ->
    !! "src/**/*.sln" |> build
)

Target "Run" (fun _ ->
    shell "src/Pocket.Logging.Demo/bin/Release/Pocket.Logging.Demo.exe" ""
)

"Build" ==> "Run"

RunTargetOrDefault "Build"