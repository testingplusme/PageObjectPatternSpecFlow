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
            bat "\"${tool 'msbuild'}\" PageObjectPatternPoll.sln /p:Configuration=Release"
          }
        }

      }
    }
  }
}