package com.codecool.the_recruitables.offer_oasis_tests.pageFactory;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;
import java.util.Objects;

public class LoginPage {
    WebDriver chromedriver;
    WebDriverWait wait;

    String URL = "http://localhost:3000/login";
    @FindBy(id = "email")
    WebElement emailField;
    @FindBy(id = "password")
    WebElement passwordField;
    @FindBy(id = "login")
    WebElement loginBtn;
    @FindBy(id = "logged-in-as")
    WebElement userNameText;

    public LoginPage(WebDriver driver) {
        this.chromedriver = driver;
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(2));
        PageFactory.initElements(driver, this);
        wait = new WebDriverWait(chromedriver, Duration.ofSeconds(15));
    }

    public void openLoginPage() {
        chromedriver.get(URL);
    }

    public void fillOut_emailField(String emailAddress) {
        emailField.sendKeys(emailAddress);
    }

    public void fillOut_passwordField(String password) {
        passwordField.sendKeys(password);
    }

    public void click_LoginButton() {
        loginBtn.click();
    }

    public String verifyLogin() {
        return userNameText.getText();
    }

    public boolean verifyPageURL() {
        return Objects.equals(chromedriver.getCurrentUrl(), URL);
    }

    public void loginAsAdmin() {
        openLoginPage();
        fillOut_emailField("admin@admin.com");
        fillOut_passwordField("admin123");
        click_LoginButton();
        wait.until(ExpectedConditions.urlContains("products"));
    }


}
