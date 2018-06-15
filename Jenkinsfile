pipeline {
  agent any
  stages {
    stage('Build code') {
      steps {
        script {
          node {
            stage 'Checkout'
            checkout scm

            stage 'Build'
            bat 'nuget restore PageObjectPatternPoll.sln'
            def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
            bat "${msbuild} SimpleWindowsProject.sln"
          }
        }

      }
    }
  }
}