# dotnet-webapi
A simple .NET Web API to try out GitHub Actions with docker buildx, Grafana Agent for Logging and Tracing and argo-tunnel to share Kubernetes Services with the Internet.

# Steps after cloning the repository
* Define secrets DOCKERHUB_USERNAME and DOCKERHUB_TOKEN which are used from the GitHub action to push the multi-plattform images to the container registry (in this case Docker Hub).
