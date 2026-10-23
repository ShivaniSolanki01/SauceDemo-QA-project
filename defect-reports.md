
# SauceDemo Defect Reports

## DEF-001: Product Sorting Error

| Field | Details |
|---|---|
| Defect ID | DEF-001 |
| Related Test Case | TC-017 |
| Test Account | `error_user` |
| Severity | Major |
| Priority | Medium |
| Status | Open |

### Description
An error message appeared when sorting products using the `error_user` account.

### Steps to Reproduce
1. Open https://www.saucedemo.com/.
2. Log in as `error_user`.
3. Select a product sorting option.
4. Observe the result.

### Expected Result
Products should be sorted according to the selected option.

### Actual Result
The application displayed the message:

`Sorting is broken! This error has been reported to Backtrace.`

### Evidence
- `evidence/Sorting error.png`

---

## DEF-002: Last Name Input Issue

| Field | Details |
|---|---|
| Defect ID | DEF-002 |
| Related Test Case | TC-019 |
| Test Account | `problem_user` |
| Severity | Major |
| Priority | Medium |
| Status | Open |

### Description
The Last Name field was reported as not accepting text during checkout testing.

### Steps to Reproduce
1. Open https://www.saucedemo.com/.
2. Log in as `problem_user`.
3. Add a product to the cart.
4. Proceed to checkout.
5. Attempt to enter a last name.

### Expected Result
The Last Name field should accept text input.

### Actual Result
The Last Name field was reported as not accepting input.

### Evidence
- `evidence/LastNameError.png`

---

## DEF-003: Postal Code Validation

| Field | Details |
|---|---|
| Defect ID | DEF-003 |
| Related Test Case | TC-020 |
| Test Account | `problem_user` |
| Severity | Minor |
| Priority | Low |
| Status | Open |

### Description
The Postal Code field accepted alphabetic characters during checkout testing.

### Steps to Reproduce
1. Open https://www.saucedemo.com/.
2. Log in as `problem_user`.
3. Add a product to the cart.
4. Proceed to checkout.
5. Enter alphabetic characters in the Postal Code field.
6. Continue and observe the result.

### Expected Result
Postal Code input should follow the application's intended validation rules.

### Actual Result
Alphabetic characters were accepted.

### Evidence
- `evidence/PostCodeValidation.png`
---

## DEF-004: UI Misalignment

| Field | Details |
|---|---|
| Defect ID | DEF-004 |
| Related Test Case | TC-021 |
| Test Account | `visual_user` |
| Severity | Minor |
| Priority | Medium |
| Status | Open |

### Description
UI misalignment was observed while testing the application with the `visual_user` account.

### Steps to Reproduce
1. Open https://www.saucedemo.com/.
2. Log in as `visual_user`.
3. Inspect the cart icon and checkout interface.
4. Observe the alignment of the affected elements.

### Expected Result
UI elements should be properly aligned and consistently positioned.

### Actual Result
Misalignment was observed in the interface.

### Evidence
- `evidence/Visual error.png`
- `evidence/checkout btn.png`
