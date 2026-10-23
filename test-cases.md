# SauceDemo — Test Cases

## 1. Document Overview

| Attribute | Details |
|---|---|
| Project | SauceDemo Software Quality Assurance Project |
| Application | [SauceDemo](https://www.saucedemo.com/) |
| Document | Functional Test Cases |
| Testing Types | Functional, negative, validation and UI testing |
| Test Environment | Web browser |
| Status | In Progress |
| Version | 1.0 |

## 2. Objective

This document records manual testing of the SauceDemo web application. Testing covers login, product sorting, shopping cart operations, checkout, order completion and account-specific behaviour.

Each test case includes its preconditions, steps, expected result, actual result and execution status where available. Screenshots are referenced where evidence has been captured.

## 3. Test Environment and Test Data

**Application URL:** https://www.saucedemo.com/

### Test Accounts

| Username | Testing Purpose |
|---|---|
| `standard_user` | Standard shopping workflows |
| `locked_out_user` | Login restriction validation |
| `problem_user` | Account-specific behaviour |
| `performance_glitch_user` | Performance-related behaviour |
| `error_user` | Account-specific functional behaviour |
| `visual_user` | Visual consistency testing |

## 4. Test Execution Status Definitions

| Status | Definition |
|---|---|
| Pass | Observed behaviour matches the expected result. |
| Fail | Observed behaviour differs from the expected result. |
| Investigate | Further verification is required. |
| Partially Verified | Some, but not all, expected behaviour has been verified. |

## 5. Test Cases

### TC-001 — Successful Login

**Priority:** High

**Preconditions:** The login page is accessible.

**Steps:**
1. Navigate to the application.
2. Enter `standard_user`.
3. Enter the demo password.
4. Select **Login**.

**Expected Result:**
- Login succeeds.
- The inventory page is displayed.

**Actual Result:** Successful login and access to the inventory page were observed during manual testing.

**Status:** Pass

### TC-002 — Login with a Locked-Out Account

**Priority:** High

**Preconditions:** The login page is accessible.

**Steps:**
1. Enter `locked_out_user`.
2. Enter the demo password.
3. Select **Login**.

**Expected Result:**
- Login is rejected.
- An appropriate locked-out message is displayed.

**Actual Result:** The application displayed: `Epic sadface: Sorry, this user has been locked out.`

**Status:** Pass

**Evidence:** `evidence/locked out user.png`

### TC-003 — Login with Invalid Credentials

**Priority:** High

**Preconditions:** The login page is accessible.

**Steps:**
1. Enter `standard_user`.
2. Enter an incorrect password.
3. Select **Login**.

**Expected Result:**
- Login is rejected.
- An error message is displayed.

**Actual Result:** The application displayed: `Epic sadface: Username and password do not match any user in this service.`

**Status:** Pass

**Evidence:** `evidence/Invalid password Login.png`

### TC-004 — Sort Products by Name (A to Z)

**Priority:** Medium

**Preconditions:** The user is logged in as `standard_user`.

**Steps:**
1. Open the product sorting control.
2. Select **Name (A to Z)**.
3. Inspect the product order.

**Expected Result:** Products appear in alphabetical ascending order.

**Actual Result:** Sorting worked as expected.

**Status:** Pass

### TC-005 — Sort Products by Name (Z to A)

**Priority:** Medium

**Preconditions:** The user is logged in as `standard_user`.

**Steps:**
1. Open the product sorting control.
2. Select **Name (Z to A)**.
3. Inspect the product order.

**Expected Result:** Products appear in alphabetical descending order.

**Actual Result:** Sorting worked as expected.

**Status:** Pass

### TC-006 — Sort Products by Price (Low to High)

**Priority:** Medium

**Preconditions:** The user is logged in as `standard_user`.

**Steps:**
1. Open the product sorting control.
2. Select **Price (low to high)**.
3. Compare product prices.

**Expected Result:** Products are sorted from lowest to highest price.

**Actual Result:** Sorting worked as expected.

**Status:** Pass

### TC-007 — Sort Products by Price (High to Low)

**Priority:** Medium

**Preconditions:** The user is logged in as `standard_user`.

**Steps:**
1. Open the product sorting control.
2. Select **Price (high to low)**.
3. Compare product prices.

**Expected Result:** Products are sorted from highest to lowest price.

**Actual Result:** Sorting worked as expected.

**Status:** Pass

### TC-008 — Add a Product to the Cart

**Priority:** High

**Preconditions:** The user is logged in as `standard_user`.

**Steps:**
1. Select **Add to cart** for a product.
2. Inspect the cart indicator.
3. Open the cart.

**Expected Result:**
- The selected product appears in the cart.
- The cart indicator updates appropriately.

**Actual Result:** Adding products to the cart worked as expected.

**Status:** Pass

### TC-009 — Remove a Product from the Cart

**Priority:** High

**Preconditions:** The cart contains at least one product.

**Steps:**
1. Open the cart.
2. Select **Remove** for a product.
3. Inspect the cart contents.

**Expected Result:** The selected product is removed.

**Actual Result:** Removal worked with `standard_user`. Removal was reported not to work as expected with `error_user`.

**Status:** Pass for `standard_user`; investigate for `error_user`.

**Evidence:** `evidence/Remove button_cart.png`

**Defect Reference:** DEF-002 (provisional)

### TC-010 — Reset Application State

**Priority:** Medium

**Preconditions:** A product has been added to the cart.

**Steps:**
1. Open the navigation menu.
2. Select **Reset App State**.
3. Inspect the cart.

**Expected Result:** The cart is cleared as part of the reset.

**Actual Result:** Reset App State cleared the cart as expected.

**Status:** Pass

### TC-011 — Proceed to Checkout

**Priority:** High

**Preconditions:** The cart contains at least one product.

**Steps:**
1. Open the cart.
2. Select **Checkout**.

**Expected Result:** The checkout information page is displayed.

**Actual Result:** The checkout information page was reached during manual testing.

**Status:** Pass

**Evidence:** `evidence/checkout page.png`

### TC-012 — Submit Valid Checkout Information

**Priority:** High

**Preconditions:** The checkout information page is displayed for `standard_user`.

**Steps:**
1. Enter a first name.
2. Enter a last name.
3. Enter a postal code.
4. Select **Continue**.

**Expected Result:** The information is accepted and the checkout overview is displayed.

**Actual Result:** Checkout information was accepted with `standard_user`.

**Status:** Pass

### TC-013 — Validate Required Last Name

**Priority:** High

**Preconditions:** The checkout information page is displayed.

**Steps:**
1. Enter a first name.
2. Leave the Last Name field empty.
3. Enter a postal code.
4. Select **Continue**.

**Expected Result:** Checkout is prevented and a validation message identifies the missing last name.

**Actual Result:** The application displayed `Error: Last Name is required.`

**Status:** Pass for required-field validation.

**Evidence:** `evidence/LastNameError.png`

### TC-014 — Verify Checkout Overview

**Priority:** High

**Preconditions:** Valid checkout information has been submitted.

**Steps:**
1. Review the listed product.
2. Inspect payment and shipping information.
3. Review the displayed totals.

**Expected Result:** Product, payment, shipping and total information are displayed correctly.

**Actual Result:** The overview displayed the Sauce Labs Bolt T-Shirt at $15.99, item total of $15.99, tax of $1.28 and total of $17.27. The screenshot confirms the displayed values; independent calculation verification is not recorded here.

**Status:** Partially Verified

**Evidence:** `evidence/CheckoutPage2.png`

### TC-015 — Complete an Order

**Priority:** High

**Preconditions:** The checkout overview page is displayed.

**Steps:**
1. Review the order.
2. Select **Finish**.
3. Inspect the confirmation page.

**Expected Result:** The order workflow completes and a confirmation message is displayed.

**Actual Result:** The application displayed `Thank you for your order!`

**Status:** Pass

**Evidence:** `evidence/order confirmation.png`

### TC-016 — Generate PDF Order

**Priority:** Medium

**Preconditions:** The order confirmation page is displayed.

**Steps:**
1. Select **Generate PDF order**.
2. Observe the browser download notification.

**Expected Result:** The order PDF is generated and downloaded.

**Actual Result:** The browser displayed a download notification for `swag-labs-order-2026-10-23_11-59-36.pdf`. The file contents have not been verified here.

**Status:** Partially Verified

**Evidence:** `evidence/PDFGenerate.png`

### TC-017 — Investigate Product Sorting with error_user

**Priority:** Medium

**Preconditions:** The user is logged in as `error_user`.

**Steps:**
1. Open the inventory page.
2. Select a product sorting option.
3. Record the displayed message.

**Expected Result:** The sorting behaviour is recorded and compared with the expected behaviour.

**Actual Result:** The application displayed: `Sorting is broken! This error has been reported to Backtrace.`

**Status:** Investigate

**Evidence:** `evidence/Sorting error.png`

**Defect Reference:** DEF-001 (provisional)

### TC-018 — Investigate Cart Removal with error_user

**Priority:** Medium

**Preconditions:** A product has been added to the cart using `error_user`.

**Steps:**
1. Open the cart.
2. Select **Remove**.
3. Inspect the cart contents.

**Expected Result:** The selected product is removed.

**Actual Result:** Removal was reported not to work as expected. The screenshot shows the cart and Remove control but does not independently establish the outcome after clicking.

**Status:** Investigate

**Evidence:** `evidence/Remove button_cart.png`

**Defect Reference:** DEF-002 (provisional)

### TC-019 — Investigate Last Name Input with problem_user

**Priority:** High

**Preconditions:** The user is logged in as `problem_user` and has reached checkout information.

**Steps:**
1. Enter a first name.
2. Attempt to enter a last name.
3. Observe the field behaviour.

**Expected Result:** The Last Name field accepts the required input.

**Actual Result:** The field was reported not to accept input. The screenshot shows an empty field and the required-field error, but does not by itself prove why input was not accepted.

**Status:** Investigate

**Evidence:** `evidence/LastNameError.png`

**Defect Reference:** DEF-003 (provisional)

### TC-020 — Investigate Postal Code Validation with problem_user

**Priority:** Medium

**Preconditions:** The user is logged in as `problem_user` and has reached checkout information.

**Steps:**
1. Enter alphabetic characters in the Postal Code field.
2. Continue the checkout workflow if possible.
3. Record the resulting behaviour.

**Expected Result:** Validation follows the application's expected input requirements.

**Actual Result:** The field was reported to accept alphabetic characters. The expected postal-code validation rules have not been confirmed.

**Status:** Investigate

**Defect Reference:** DEF-004 (provisional)

### TC-021 — Investigate Visual Consistency with visual_user

**Priority:** Medium

**Preconditions:** The user can access the inventory, cart and checkout pages.

**Steps:**
1. Log in as `visual_user`.
2. Inspect the cart icon and checkout interface.
3. Compare the appearance with `standard_user`.

**Expected Result:** The interface is usable and visual differences are documented accurately.

**Actual Result:** Apparent alignment inconsistencies were observed in the cart icon and checkout interface. A like-for-like comparison is needed before confirming defects.

**Status:** Investigate

**Evidence:**
- `evidence/Visual error.png`
- `evidence/checkout btn.png`

**Defect Reference:** DEF-005 (provisional)
# SauceDemo Test Cases

| Test Case ID | Test Scenario | Test Steps | Test Data | Expected Result | Actual Result | Status |
|---|---|---|---|---|---|---|
| TC-001 | Login with valid credentials | Enter valid credentials and click Login. | `standard_user` | Products page is displayed. | Products page displayed successfully. | Pass |
| TC-002 | Login with locked-out account | Enter locked-out credentials and click Login. | `locked_out_user` | Login is blocked with an error message. | Locked-out error message displayed. | Pass |
| TC-003 | Login with invalid credentials | Enter an incorrect password and click Login. | Invalid password | An appropriate error message is displayed. | Invalid credentials error displayed. | Pass |
| TC-004 | Sort products A to Z | Select Name (A to Z). | `standard_user` | Products are sorted alphabetically. | Products sorted correctly. | Pass |
| TC-005 | Sort products Z to A | Select Name (Z to A). | `standard_user` | Products are sorted in reverse alphabetical order. | Products sorted correctly. | Pass |
| TC-006 | Sort prices low to high | Select Price (low to high). | `standard_user` | Products are sorted by ascending price. | Products sorted correctly. | Pass |
| TC-007 | Sort prices high to low | Select Price (high to low). | `standard_user` | Products are sorted by descending price. | Products sorted correctly. | Pass |
| TC-008 | Add product to cart | Click Add to cart and open the cart. | `standard_user` | Product appears in the cart. | Product appeared in the cart. | Pass |
| TC-009 | Remove product from cart | Add a product, open the cart, and click Remove. | `standard_user` | Product is removed from the cart. | Product was removed successfully. | Pass |
| TC-010 | Reset application state | Add a product and select Reset App State. | `standard_user` | Cart is cleared. | Cart was cleared. | Pass |
| TC-011 | Open checkout page | Open the cart and click Checkout. | `standard_user` | Checkout information form appears. | Checkout page appeared. | Pass |
| TC-012 | Submit checkout information | Enter valid details and click Continue. | Valid checkout details | Checkout overview appears. | Checkout overview appeared. | Pass |
| TC-013 | Validate required last name | Leave Last Name blank and click Continue. | Blank last name | Required-field error is displayed. | Required-field error displayed. | Pass |
| TC-014 | Verify checkout totals | Review the item, tax, and total on the overview page. | Sauce Labs Bolt T-Shirt | Order totals are calculated correctly. | Item: $15.99; tax: $1.28; total: $17.27. | Pass |
| TC-015 | Complete an order | Click Finish on the checkout overview. | Valid checkout details | Order confirmation appears. | Order confirmation appeared. | Pass |
| TC-016 | Download and verify order PDF | Generate the order PDF, open it, and verify the order confirmation. | Completed order | PDF opens and displays the order confirmation. | PDF opened successfully and displayed the order confirmation. | Pass |
| TC-017 | Sort products with error account | Log in and select a sorting option. | `error_user` | Sorting works as expected. | Sorting error message displayed. | Fail |
| TC-018 | Remove cart item with error account | Add a product, open the cart, and click Remove. | `error_user` | Product is removed from the cart. | Product was removed successfully. | Pass |
| TC-019 | Enter last name with problem account | Open checkout and enter a last name. | `problem_user` | Last-name field accepts input. | Last-name input did not work as expected. | Fail |
| TC-020 | Validate postal code with problem account | Enter alphabetic characters in Postal Code. | `problem_user` | Postal code follows the expected validation rules. | Alphabetic characters were accepted. | Fail |
| TC-021 | Inspect UI alignment | Inspect the cart icon and checkout interface. | `visual_user` | UI elements are aligned consistently. | Misalignment was observed. | Fail |

## 6. Defect Traceability

Unexpected behaviours are documented in `defect-reports.md` and linked to their corresponding test case IDs.

Each defect report should include:
- Defect ID and summary
- Test account and relevant environment
- Preconditions and reproduction steps
- Expected and actual results
- Severity and priority, where justified
- Supporting evidence
- Status and retest results, where applicable

Account-specific behaviours should be investigated against the intended behaviour of SauceDemo before being classified as confirmed defects.
