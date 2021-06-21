import { AppPage } from './app.po';
import { browser, logging } from 'protractor';
import { createWriteStream } from 'fs';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  afterEach(() => {
    browser.takeScreenshot().then((png) =>{
      var stream = createWriteStream("samplescreenshot.png"); /** change the png file name  */
    stream.write(new Buffer(png, 'base64'));
    stream.end; 
    });
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getTitleText()).toEqual('Welcome to T14-HOL001!');
  });

  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });
});
