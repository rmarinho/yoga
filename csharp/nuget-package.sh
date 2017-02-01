#!/bin/bash

#Nuget pack
mkdir artifacts
nuget update -self
nuget pack nuget/Facebook.Yoga.Xamarin.nuspec  -OutputDirectory artifacts -Version 1.0.1-pre1