import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get(browser.baseUrl) as Promise<any>;
  }

  getTitleText() {
    return element(by.css('app-root h1')).getText() as Promise<string>;
  }

  setNewProduct(product: string) {
    element(by.id('newProduct')).sendKeys(product);
  }

  clickAddProduct() {
    element(by.id('addProductBtn')).click();
  }

  getProductsList() {
    return element.all(by.css('.list-group li')).last().getText();
  }
}
