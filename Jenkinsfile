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
            cmd 'nuget restore PageObjectPatternPoll.sln'
            cmd "\"${tool 'MSBuild'}\" PageObjectPatternPoll.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

          }
        }

      }
    }
  }
}