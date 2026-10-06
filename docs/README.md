# Login Page

A simple, responsive sign-in page built with plain HTML and CSS. It is suitable as a starting point for an admin panel, LMS, or other web application.

## Files

- `login.html` – The complete login page, including its current internal CSS.

## Run the project

No installation is required.

1. Download or clone the project.
2. Open `login.html` in any modern web browser.

For live reload during development, you may use the **Live Server** extension in Visual Studio Code.

## Included features

- Responsive layout for desktop and mobile devices
- Email and password fields with browser validation
- Remember-me checkbox
- Forgot-password and account-registration links
- Keyboard-friendly form controls and focus states

## CSS options

The current page uses **internal CSS**, placed in the `<style>` section inside `login.html`.

### Inline CSS

CSS is applied directly to one HTML element:

```html
<h1 style="color: blue;">Welcome</h1>
```

### Internal CSS

CSS is written inside the same HTML file:

```html
<style>
  h1 { color: blue; }
</style>
```

### External CSS

For larger projects, move styles to a separate file, such as `style.css`:

```html
<link rel="stylesheet" href="style.css">
```

## Important note

This is a front-end template only. To make sign-in work, connect the form to a secure back-end authentication system and never store plain-text passwords.
