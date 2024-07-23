# Blog API

The core functionality of this platform includes managing blog posts and their
associated comments.

## Demo
 https://www.loom.com/share/346e17277584456d9bce246a062d67eb

## Run the components

This API uses Microsoft SQL Server, MongoDB, RabbitMQ and also a .NET Aspire to collect metrics and logs.
In the root folder of the project, there is a file called `docker-compose.yml`. To run the necessary infrastructure, you need to execute the command `docker-compose up` in the directory containing this file.

## Run the project

After running the `docker-compose.yml` file, you can run the project located in the `\src\Blog.Api\` directory using the command `dotnet run https` and then access the address `http://localhost:5265/swagger/index.html` to view the Swagger documentation.

## Next 

- Add resilience to the queue and integration components, including retry and, if necessary, circuit breaker.
- Add distributed caching for the post endpoint.
- Add API versioning.
- Add more unit tests.
- Add integration tests using SpecFlow and Testcontainers.

