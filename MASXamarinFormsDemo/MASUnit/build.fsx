#r "tools/FAKE/FakeLib.dll"

open Fake
open Fake.XamarinHelper

let buildAndroidDir  = "/MASUnit.Android/bin/Debug/"
let buildiOSDir  = "/MASUnit.iOS/bin/iPhoneSimulator/Debug/"
let testDir   = "./test/"
let testAndroidDlls = !! "//MASUnit.Android/bin/Debug/*.dll"
let testiOSDlls = !! "//MASUnit.iOS/bin/iPhoneSimulator/Debug/*.dll"
let solution = "MASUnit"
let iOSproject = "MASUnit.iOS.csproj"
let androidproject = "MASUnit.Android.csproj"


Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "Build-iOS" (fun _ ->
    iOSBuild (fun defaults -> 
        { 
            defaults with ProjectPath = iOSproject
                          OutputPath = buildiOSDir
                          Configuration = "Debug|iPhoneSimulator"
                          Target = "Build"
        })
)

Target "Test-MASUnit-iOS" (fun _ ->
    testiOSDlls
        |> NUnit (fun p ->
            {p with
                DisableShadowCopy = true;
                OutputFile = testDir + "TestResults.xml"})
)

Target "Build-Android" (fun _ ->
    !! (androidproject  MASUnit.Android.csproj"
        |> MSBuild buildAndroidDir "Build" [ ("Configuration", "Debug"); ("Platform", "Any CPU") ]
        |> Log "----Android build output----"
)

Target "Test-MASUnit-Android" (fun _ ->
    testAndroidDlls
        |> NUnit (fun p ->
            {p with
                DisableShadowCopy = true;
                OutputFile = testDir + "TestResults.xml"})
)

Target "Deploy-iOS" (fun _ ->
    !! (iOSbuildDir + "/**/*.*")
        -- "*.zip"
        |> Zip buildiOSDir (deployDir + "iOS.MASUnit" + ".zip")
)

Target "Deploy-Android" (fun _ ->
    !! (buildAndroidDir + "/**/*.*")
        -- "*.zip"
        |> Zip buildDir (deployDir + "Android.MASUnit" + ".zip")
)

// Build order
"Clean"
  ==> "Build-iOS"
  ==> "Test-MASUnit-iOS"
  ==> "Deploy-iOS"
  ==> "Build-Android"
  ==> "Test-MASUnit-Android"
  ==> "Deploy-Android"


RunTargetOrDefault "Deploy-Android"