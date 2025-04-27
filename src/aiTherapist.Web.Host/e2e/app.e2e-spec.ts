import { aiTherapistTemplatePage } from './app.po';

describe('aiTherapist App', function() {
  let page: aiTherapistTemplatePage;

  beforeEach(() => {
    page = new aiTherapistTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
