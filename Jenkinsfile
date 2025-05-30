pipeline {
    agent any
    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
    }

    stages {
        stage('Restore All Services') {
            parallel {
                stage('Restore BookingService') {
                    steps {
                        dir('Services/BookingService') {
                            bat 'dotnet restore BookingService.csproj'
                        }
                    }
                }
                stage('Restore FlightService') {
                    steps {
                        dir('Services/FlightService') {
                            bat 'dotnet restore FlightService.csproj'
                        }
                    }
                }
                stage('Restore UserService') {
                    steps {
                        dir('Services/UserService') {
                            bat 'dotnet restore UserService.csproj'
                        }
                    }
                }
                stage('Restore CheckInService') {
                    steps {
                        dir('Services/CheckInService') {
                            bat 'dotnet restore CheckInService.csproj'
                        }
                    }
                }
            }
        }

        stage('Build All Services') {
            parallel {
                stage('Build BookingService') {
                    steps {
                        dir('Services/BookingService') {
                            bat 'dotnet build BookingService.csproj --no-restore'
                        }
                    }
                }
                stage('Build FlightService') {
                    steps {
                        dir('Services/FlightService') {
                            bat 'dotnet build FlightService.csproj --no-restore'
                        }
                    }
                }
                stage('Build UserService') {
                    steps {
                        dir('Services/UserService') {
                            bat 'dotnet build UserService.csproj --no-restore'
                        }
                    }
                }
                stage('Build CheckInService') {
                    steps {
                        dir('Services/CheckInService') {
                            bat 'dotnet build CheckInService.csproj --no-restore'
                        }
                    }
                }
            }
        }

        stage('Test Placeholder') {
            steps {
                echo 'You can add unit tests for each service here.'
            }
        }

        stage('Publish All Services') {
            parallel {
                stage('Publish BookingService') {
                    steps {
                        dir('Services/BookingService') {
                            bat 'dotnet publish BookingService.csproj -c Release -o published'
                        }
                    }
                }
                stage('Publish FlightService') {
                    steps {
                        dir('Services/FlightService') {
                            bat 'dotnet publish FlightService.csproj -c Release -o published'
                        }
                    }
                }
                stage('Publish UserService') {
                    steps {
                        dir('Services/UserService') {
                            bat 'dotnet publish UserService.csproj -c Release -o published'
                        }
                    }
                }
                stage('Publish CheckInService') {
                    steps {
                        dir('Services/CheckInService') {
                            bat 'dotnet publish CheckInService.csproj -c Release -o published'
                        }
                    }
                }
            }
        }
    }
}
