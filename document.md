﻿# CLEAN ARCHITECTURE
---
### [Flow Code Demo](https://mermaid.live/edit#pako:eNqNU11v2jAU_SuWn1opS_MFSfxQiQKTeJg2kW2Vqry48QUsJXZmO2gM8d_rxNBB4aF-su895x7frz2uJANMsIY_HYgKZpyuFW1KgexpqTK84i0VBk1rDsJc25_hddLya_ukbWteUcOluHbOZEP5DftCrBTVRnWV6RSUR4ST_vL46LQI-vG9-IkeaMsfOg1KO5RzWtSZMkFTBdTALwubyqahgjnwGeYj4zetORvuT7ChWy4Vuvta2-KY_577W1FcUidJ1GuiuTDc7Bza-c-AS8q1wzkKm2_fS3wZ-rIuBC160hJaqbmRaudPGJvonaju-nocP3fJuRGkoFtARqIZNfSVaviU8Nx-vS5AbXkFfgGCPUNdyQYG-2eFLQ2dES4lT01egu5q4xddVYHWQ2YLdv-h1240CIqC8Fh322Ds4bXiDBMrCR5uQFkt-8T7nl1is4EGSkzslcGKWpUSl-JgaXYIX6RsTkwlu_UGkxWttX11rW3-aUHeITaXfrY6YTCJoyEEJnv8F5MwjPw4H2V5kqVhnGZJ7uEdJlHqR8k4j-MoC5PROB1HBw__G1QDP0vzIAzydBSPgywNEg8D61v8zW3psKyHN4BgQkI)

### [Mini Project Flow To Visualize Source](https://mermaid.live/edit#pako:eNp9VF1r2zAU_StGUNggDXHtNLYZhTZuiWGFsi57mL0HxbpJBLZkZDlbFvrfdyU7q5JA_eJ7ju4990voQErJgCRkXcnf5ZYq7X1PC-Hh13arjaLN1ntR0ILQVHMpchd4X-kelHf_kv3qQ8w3z-dSaCWrCtSXlbqbK6Aali06PgrWSC704A2CFeIs133TVLzsUzl2n8nNUrP8XXku65oK5pz_oFX-VHVYKVqcWZHTagZeuqoLR3OBgtVJzux1V-aZOXsFteMlGMFMaFBrWsIHTaWyplzk_e-ilWU-DEdzvTeSg98zLqZy_B532M1RxALjbNu3RTPLfVBGJtaKtlp1pe4U5Kfwoqxv0EhbmTFajoOyxfG6qaDGRK2XnZ46sWZQZ3M6jxuOnKD0If-UUk1XtIXPl21cXXlPeEe9UgoBpdln2x_MvevrO3MhBlgzS-B-ewINSyx6uLBg6QKz2B4by1L_mSNh-uwZY1kqfXBF7PQLQUZkozgjCQ4WRqQGhftCSA7GuSB6i1MoSIImgzXtKl2QQrxhWEPFTynrY6SS3WZLkjWtWkRdg3cVUk5xle8uOB5z-TuhSRJMJ1aDJAfyhyTTeBzFQTwNojic3c5uo3BE9iTxg5tx4Ps3UeyH_iScBdHbiPy1af2xH8Y-OoZ-NJlG0xEBZhb73D8Q9p14-wcFmlco)

### Package need be install:
    - MediatR
    # Reusable Services for Enhanced Performance and Reduced Coding Errors
    - FluentValidation (It still not  support for .NET 9.0) - change to use DataAnnotations 
    - Swashbuckle.AspNetCore
    # Reusable Services for Enhanced Performance and Reduced Coding Errors
    
    ---
## Table of Contents

* [Project Overview](#project-overview)
  * [Included Services](#included-services)
  * [Test Structure](#test-structure)
  * [Knowledge Areas](#knowledge-areas)
* [Why FluentValidation Is Better Than DataAnnotations](#why-fluentvalidation-is-better-than-dataannotations)
  * [1. Separation of Logic](#separation-of-logic)
  * [2. More Powerful and Flexible Rules](#more-powerful-and-flexible-rules)
  * [3. Better Error Messages](#better-error-messages)
  * [4. Context-Based Validation](#context-based-validation)
  * [5. Easier to Test](#easier-to-test)
  * [6. Scales Better for Large Projects](#scales-better-for-large-projects)
* [Logger](#logger)
  * [1. Overview](#1-overview)
  * [2. Levels of Logging](#2-levels-of-logging)
  * [3. Structured Logging](#3-structured-logging)
  * [4. Correlation ID / Trace ID](#4-correlation-id--trace-id)
  * [5. Retention Policy](#5-retention-policy)
  * [6. Where Should the Logger Be Placed?](#6-where-should-the-logger-be-placed)
  * [7. Best Practice to Not Overload the Server](#7best-practice-to-not-overload-the-server)
  * [8. Diagram](#8-diagram)


 ---

# Project Overview

This project provides reusable services that can be integrated into other projects to **increase performance** and **reduce coding errors**.

### Included Services

* **Exception Handling Service** – centralized error handling with best practices.
* **Swagger Service** – for API documentation following industry standards.

### Test Structure

The project follows clean architecture principles and includes a `tests/` folder with two subfolders:

* `tests/e2e/` → End-to-End tests.
* `tests/integration/` → Integration tests.

### Knowledge Areas

* Error handling best practices.
* API documentation standards.
* Testing strategies (end-to-end and integration).
* Clean architecture principles.
* FluentValidation for input validation.
* Loggers.

---

# Why FluentValidation Is Better Than DataAnnotations

### Separation of Logic

* **DataAnnotations**: Validation rules are mixed directly into the model, making it messy since it holds both **data** and **rules**.
* **FluentValidation**: Keeps rules in a separate file. Models stay clean, and validation is easier to manage.

---

### More Powerful and Flexible Rules

* **DataAnnotations**: Limited to basic attributes like `[Required]`, `[MaxLength]`, `[Range]`.
* **FluentValidation**: Supports custom rules, chaining, conditions, and regex.

```csharp
RuleFor(x => x.Password)
    .NotEmpty()
    .MinimumLength(8)
    .Matches("[A-Z]").WithMessage("Must contain at least one uppercase letter")
    .Matches("[0-9]").WithMessage("Must contain at least one number");
```

=> To achieve this with DataAnnotations, you’d need custom attributes -> more code, more complexity.

---

### Better Error Messages

* **DataAnnotations**: Uses fixed messages, harder to customize.
* **FluentValidation**: Allows custom messages per rule, supports multiple languages, and can adapt messages dynamically.

---

### Context-Based Validation

* **DataAnnotations**: Poor support for scenario-specific rules.
* **FluentValidation**: Supports conditional rules and **rule sets** (e.g., registration vs. profile update).

---

### Easier to Test

* **DataAnnotations**: Validation tied directly to the model, making unit testing harder.
* **FluentValidation**: Rules can be tested **independently** with unit tests.

---

### Scales Better for Large Projects

* **DataAnnotations**: Works fine for small applications.
* **FluentValidation**: Much easier to maintain and extend in large projects with **hundreds of models and thousands of rules**.

---

 **Conclusion**: DataAnnotations are simple but limited. FluentValidation is clean, flexible, testable, and built to scale with your project.

 ---

# Logger
### 1. Overview
A logger is a tool that records events, messages, or data during the execution of a program. It helps developers track the flow of their application, identify issues, and understand user behavior. Loggers can capture various levels of information, such as debug messages, errors, warnings, and informational messages.

### 2. Levels of Logging
Level-based logging:
 - Trace: Very detailed information, typically of interest only when diagnosing problems.
 - Debug: Information useful for debugging the application.
 - Information: General information about the application's operation.(login user, validated request)
 - Error: serious error, but the system is still running.
 - Warning: Something unexpected happened, but the system is still running.(retry fail, low connection)
 - Critical: System down, need to handle immediately.
-> Rule: log at the correct level - avoid over-logging or under-logging.

### 3. Structured Logging
  
  - Not just log text, but log key-value for easy analysis later.
   
   ```csharp
  _logger.LogInformation("User {UserId} created at {Time}", user.Id, DateTime.UtcNow);
   ```

   This data will be easier to query when entering Elastic/Seq/Datadog.

### 4. Correlation ID / Trace ID
  - Add a unique ID to trace log from frontend → backend (frontend → API → DB).
  - Helps in debugging distributed systems.
  - Integration with Distributed Tracing (OpenTelemetry, Jaeger).

### 5. Retention policy
  - Define how long to keep logs based on their importance.
  - Archive or delete old logs to save storage.
  - Push logs to centralized log system (ELK, Grafana Loki, Application Insights, Seq).
### 6. Where should the logger be placed?
  - **Application Layer**:
    - Log for Command/Query Handler (success, fail, validation).
  - **Infrastructure Layer**:
    - Log when calling DB, external API, message broker.
  - **Middleware (Global)**:
    - Log Request/Response + Exception Handling (global error handler).

### 7.Best Practice to not overload the server
  - Don't log everything in Debug/Trace in production → only enable when needed.
  - Async logging: use Serilog, NLog for non-blocking logging.
  - Centralized logging: push to (Elastic, Seq, Application Insights), don't save too many files on the server.
  - Sampling log: with large traffic, only log a part of the request (eg 1%).

### 8. Diagram
   [Flow](https://mermaid.live/edit#pako:eNplkt1q4zAQhV9F6GoLbqpYsVN8UWiTQAIJlG1hl7V7MY0mjsCW0rHcvyTvXsnekrA7VxrNOd-MBu352irkGd9U9m29BXLs8a4wzEfTPpcEuy27vV_0NyFW-UorVeEbEGbsJ7602Di2tGWpTfl00s3zORivI3bFHpBe9Rr_VtGowvzTYmE2BCfz9C7_MQUHz9DgxRl09vsxn707JANVGOt_4opdXt4cJpYIK3DamoU6sHm49NBe0mcede6YEVmKwhz2wJZ5eI8f_Z7sq1ZIT2fOwy8g498asc7j1X1x2WEn-QSNI6j0J6qwFvbw0TisPYFHvCSteOaoxYjXSDWElO8DoOBuizUWPPNHhRtoK1fwwhy9bQfmj7X1t5NsW255toGq8Vm7U-BwqsFv8iTxK0Ga2NY4ng1l0jF4tufvPIvHchAncZoIGV8n6XA8ivhHUI0GiRQiTcZCDJNhGh8j_tm1FYOxTIWQ1zJOpExGwjtQaWdp1X-e7g8dvwCw4bIF)

# Caching
### 1. Target to cache
 - Reduce DB load: No repeated queries with data that changes little.

 - API Speedup: Faster response due to fetching from memory.

 - Abstract Cache Layer: so that later if you want to change from In-Memory → Redis, you only need to change the implementation, without affecting the Application Layer.

### 2. Position in Clean Architecture
 - Application Layer: Cache for Command/Query Handler (eg: GetUserById, GetProduct), declare ICacheService interface (only define contract, don't know whether to use In-Memory or Redis).
 - Infrastructure Layer: Implement CacheService (In-Memory or Redis).
 - Presentation Layer: Use CacheService in Controller/Endpoint (eg: GetProductById, GetAllProducts), Only call service → don't care about implementation.