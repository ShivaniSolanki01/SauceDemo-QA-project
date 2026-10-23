# SauceDemo — Software Quality Assurance Project

A practical software testing project demonstrating a structured approach to functional testing, test design, defect analysis and UI test automation for a demo e-commerce application.

## Project Overview

This project focuses on evaluating the functionality and usability of [SauceDemo](https://www.saucedemo.com/), a web-based sample shopping application.

The objective is to apply software testing principles to realistic user workflows, identify potential issues, document test outcomes and develop maintainable automated UI tests.

The repository serves as a practical portfolio demonstrating QA methodologies, analytical thinking and a quality-focused approach to software delivery.

## Project Objectives

- Design structured test cases with clear preconditions, steps and expected results.
- Validate core e-commerce workflows and business rules.
- Test positive, negative and boundary scenarios.
- Verify product sorting, shopping cart operations and checkout validation.
- Document reproducible defects with supporting evidence where applicable.
- Develop UI automation using Selenium WebDriver, C# and NUnit.
- Maintain clear, traceable testing documentation.

## Application Under Test

| Attribute | Details |
|---|---|
| Application | SauceDemo |
| Application URL | https://www.saucedemo.com/ |
| Application type | Web-based e-commerce demo |
| Testing focus | Functional testing and UI automation |
| Automation language | C# |
| Automation framework | Selenium WebDriver and NUnit |

## Scope of Testing

### 1. Login and Authentication
- Successful login with valid credentials.
- Login validation with invalid credentials.
- Handling of empty or missing input values.
- Access to application pages after authentication.

### 2. Product Listing and Sorting
- Verification of product names, prices and displayed information.
- Sorting products by name and price.
- Validation of sorting order and product presentation.

### 3. Shopping Cart
- Adding products to the cart.
- Removing products from the cart.
- Verifying cart contents and item quantities.
- Navigating between the product listing and cart.

### 4. Checkout
- Proceeding from the cart to checkout.
- Validating required customer information.
- Verifying checkout overview details and totals.
- Completing the order workflow.

### 5. UI Automation
- Automate selected user workflows using Selenium WebDriver, C# and NUnit.
- Apply the Page Object Model (POM) to organise page interactions and improve maintainability.
- Validate login, product sorting, shopping cart operations, checkout and navigation workflows.
- Use explicit waits to handle dynamic page interactions and improve test reliability.
- Execute automated tests and investigate failures using observed results and supporting evidence.

## Testing Approach

The project follows a structured testing workflow:

1. **Understand requirements** — identify key functionality and expected behaviour.
2. **Design test scenarios** — cover positive, negative and relevant boundary conditions.
3. **Execute tests** — compare actual behaviour against expected results.
4. **Document findings** — record execution status and reproducible defects where identified.
5. **Automate selected scenarios** — implement and execute UI tests using Selenium WebDriver, C# and NUnit.
6. **Review evidence** — retain relevant test reports and screenshots to support findings.

## Tools and Technologies

| Tool / Technology | Purpose |
|---|---|
| Manual Testing | Functional validation and exploratory testing |
| Selenium WebDriver | Browser-based UI automation |
| C# | Automation test development |
| NUnit | Test organisation and execution |
| Git and GitHub | Version control and project documentation |

## Repository Structure
saucedemo-qa-project/
├── Evidence/
├── automation/
│   ├── Base/
│   │   └── BaseTest.cs
│   ├── Page.cs/
│   │   ├── LoginPage.cs
│   │   ├── ProductsPage.cs
│   │   ├── CartPage.cs
│   │   └── CheckoutPage.cs
│   ├── Tests/
│   │   ├── LoginTests.cs
│   │   ├── ProductTests.cs
│   │   ├── CartTests.cs
│   │   ├── CheckoutTests.cs
│   │   ├── OrderTests.cs
│   │   └── NavigationTests.cs
│   └── SauceDemo.Tests.csproj
├── README.md
├── test-cases.md
└── defect-reports.md

The repository contains manual test documentation, defect reports, supporting evidence and automated UI tests developed using Selenium WebDriver, C# and NUnit.

```

## Test Documentation

- **Test Cases** — test scenarios, preconditions, execution steps, expected results, actual results and status.
- **Defect Reports** — reproducible issues, severity, reproduction steps, expected versus actual behaviour and supporting evidence, where applicable.
- **Automation** — source code for selected automated test scenarios.
- **Evidence** — relevant screenshots and execution reports.

## Quality and Reporting Principles

- Test results reflect scenarios actually executed.
- Expected and actual results are recorded separately.
- Defects are documented only when supported by observed behaviour.
- Automation claims are supported by committed source code and execution evidence.
- Project documentation is updated as testing artefacts are verified.

## Project Status

**SauceDemo QA Portfolio Project**

The project includes documented manual test cases, defect reports with supporting evidence, and automated UI tests using Selenium WebDriver, C# and NUnit. The latest recorded automation run completed with 24 tests passing. Further improvements may be made as the project documentation and portfolio are refined.

## About

**Shivani Solanki** - Test Analyst | Software Quality Assurance

[Portfolio Website](https://shivani.qa-analyst.com/)
[LinkedIn Profile](https://www.linkedin.com/in/shivanisolanki01/)
