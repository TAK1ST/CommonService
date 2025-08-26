# CLEAN ARCHITECTURE
### [Flow Code Demo](https://mermaid.live/edit#pako:eNqNU11v2jAU_SuWn1opS_MFSfxQiQKTeJg2kW2Vqry48QUsJXZmO2gM8d_rxNBB4aF-su895x7frz2uJANMsIY_HYgKZpyuFW1KgexpqTK84i0VBk1rDsJc25_hddLya_ukbWteUcOluHbOZEP5DftCrBTVRnWV6RSUR4ST_vL46LQI-vG9-IkeaMsfOg1KO5RzWtSZMkFTBdTALwubyqahgjnwGeYj4zetORvuT7ChWy4Vuvta2-KY_577W1FcUidJ1GuiuTDc7Bza-c-AS8q1wzkKm2_fS3wZ-rIuBC160hJaqbmRaudPGJvonaju-nocP3fJuRGkoFtARqIZNfSVaviU8Nx-vS5AbXkFfgGCPUNdyQYG-2eFLQ2dES4lT01egu5q4xddVYHWQ2YLdv-h1240CIqC8Fh322Ds4bXiDBMrCR5uQFkt-8T7nl1is4EGSkzslcGKWpUSl-JgaXYIX6RsTkwlu_UGkxWttX11rW3-aUHeITaXfrY6YTCJoyEEJnv8F5MwjPw4H2V5kqVhnGZJ7uEdJlHqR8k4j-MoC5PROB1HBw__G1QDP0vzIAzydBSPgywNEg8D61v8zW3psKyHN4BgQkI)

### [Mini Project Flow To Visualize Source](https://mermaid.live/edit#pako:eNp9VF1r2zAU_StGUNggDXHtNLYZhTZuiWGFsi57mL0HxbpJBLZkZDlbFvrfdyU7q5JA_eJ7ju4990voQErJgCRkXcnf5ZYq7X1PC-Hh13arjaLN1ntR0ILQVHMpchd4X-kelHf_kv3qQ8w3z-dSaCWrCtSXlbqbK6Aali06PgrWSC704A2CFeIs133TVLzsUzl2n8nNUrP8XXku65oK5pz_oFX-VHVYKVqcWZHTagZeuqoLR3OBgtVJzux1V-aZOXsFteMlGMFMaFBrWsIHTaWyplzk_e-ilWU-DEdzvTeSg98zLqZy_B532M1RxALjbNu3RTPLfVBGJtaKtlp1pe4U5Kfwoqxv0EhbmTFajoOyxfG6qaDGRK2XnZ46sWZQZ3M6jxuOnKD0If-UUk1XtIXPl21cXXlPeEe9UgoBpdln2x_MvevrO3MhBlgzS-B-ewINSyx6uLBg6QKz2B4by1L_mSNh-uwZY1kqfXBF7PQLQUZkozgjCQ4WRqQGhftCSA7GuSB6i1MoSIImgzXtKl2QQrxhWEPFTynrY6SS3WZLkjWtWkRdg3cVUk5xle8uOB5z-TuhSRJMJ1aDJAfyhyTTeBzFQTwNojic3c5uo3BE9iTxg5tx4Ps3UeyH_iScBdHbiPy1af2xH8Y-OoZ-NJlG0xEBZhb73D8Q9p14-wcFmlco)

### Package need be install:
    - MediatR
    # Reusable Services for Enhanced Performance and Reduced Coding Errors
    - FluentValidation (It still not  support for .NET 9.0) - change to use DataAnnotations 
    - Swashbuckle.AspNetCore
    # Reusable Services for Enhanced Performance and Reduced Coding Errors

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

