# EventHub "Event Management Platform"

 * .Net 7
 * Microservices Architecture
 * DDD
 * Clean Architecture
 * CQRS
 * Event-Driven Architecture
 * Message Broker (RabbitMQ)
 * Docker

# Build status
![Status](https://github.com/mamohammadi/EventHub/blob/master/.github/workflows/docker-compose.yml/badge.svg?branch=master&event=push)

Event Service: This microservice handles event creation, management, and retrieval. It allows users to create events, provide event details (such as date, time, location, and description), manage registrations, and provide event-related updates.

User Service: This microservice focuses on user management functionalities, including user registration, authentication, and profile management. It provides endpoints for user-related operations and can integrate with the Event Service for user-specific event actions.

Notification Service: This microservice handles event-related notifications, such as event reminders, updates, and announcements. It can utilize email notifications, push notifications, or any other preferred communication channels.

Analytics Service: This microservice provides analytics and reporting capabilities for events. It collects and analyzes data related to event attendance, user engagement, and other relevant metrics, offering insights to event organizers.

Dockerization: Containerize each microservice using Docker, providing individual Dockerfiles for each service. Specify the dependencies, configurations, and instructions to build and run each microservice within their respective Dockerfiles.

Container Orchestration: Utilize Docker Compose or Kubernetes for container orchestration. Define the necessary services, network configurations, and inter-service communication within the orchestration tool for easy deployment and scalability.
