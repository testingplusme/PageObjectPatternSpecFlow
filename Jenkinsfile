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
            bat"\"${tool 'MSBuild'}\" PageObjectPatternPoll.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

          }
        }

      }
    }
  }
}