import { TestBed } from '@angular/core/testing';
import { DataService } from './data.service';
import { Post } from './post.model';
import {HttpTestingController,HttpClientTestingModule} from '@angular/common/http/testing';

describe('DataService', () => {
  let service: DataService;
  let httpMock: HttpTestingController;
  beforeEach(() => {
      TestBed.configureTestingModule({
          imports: [HttpClientTestingModule],
          providers: [DataService]
      });
      service = TestBed.get(DataService);
      httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
});

  it('should be created Data Service', () => {
    const service: DataService = TestBed.get(DataService);
    expect(service).toBeTruthy();
  });

  it('be able to retrieve posts from the API bia GET', () => {
    const dummyPosts: Post[] = [
      {
        userId: '1',
        id: 1,
        body: 'Welcome User 1',
        title: 'This is User 1'
        }, 
        {
        userId: '2',
        id: 2,
        body: 'Welcome User 2',
        title: 'esting AngulTar ServThis is User 2ices'
    }];
    service.getPostData().subscribe(posts => {
        expect(posts.length).toBe(2);
        expect(posts).toEqual(dummyPosts);
    });
const request = httpMock.expectOne( `${service.ROOT_URl}/posts`);
expect(request.request.method).toBe('GET');
request.flush(dummyPosts);
});
});
