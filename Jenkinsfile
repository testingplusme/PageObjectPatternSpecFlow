pipeline {
  agent any
  stages {
    stage('Build code') {
      steps {
        script {
          pipeline {
            agent {
              label 'win-slave-node'
            }
            stages {
              stage('Build') {
                steps {
                  script {
                    bat 'nuget restore PageObjectPatternPoll.sln'
                    def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
                    bat "${msbuild} PageObjectPatternPollt.sln"
                  }
                }
              }
            }
          }
        }

      }
    }
  }
}