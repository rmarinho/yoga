# Yoga [![Build Status](https://travis-ci.org/facebook/yoga.svg?branch=master)](https://travis-ci.org/facebook/yoga)

## Building
Yoga builds with [buck](https://buckbuild.com). Make sure you install buck before contributing to Yoga. Yoga's main implementation is in C, with bindings to supported languages and frameworks. When making changes to Yoga please ensure the changes are also propagated to these bindings when applicable.

## Testing
For testing we rely on [gtest](https://github.com/google/googletest) as a submodule. After cloning Yoga run `git submodule init` followed by `git submodule update`.

For any changes you make you should ensure that all the tests are passing. In case you make any fixes or additions to the library please also add tests for that change to ensure we don't break anything in the future. Tests are located in the `tests` directory. Run the tests by executing `buck test //:yoga`.

Instead of manually writing a test which ensures parity with web implementations of Flexbox you can run `gentest/gentest.rb` to generated a test for you. You can write html which you want to verify in Yoga, in `gentest/fixtures` folder, such as the following.

```html
<div id="my_test" style="width: 100px; height: 100px; align-items: center;">
  <div style="width: 50px; height: 50px;"></div>
</div>
```

Run `gentest/gentest.rb` to generate test code and re-run `buck test //:yoga` to validate the behavior. One test case will be generated for every root `div` in the input html.

You may need to install the latest watir-webdriver gem (`gem install watir-webdriver`) and [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/) to run `gentest/gentest.rb` Ruby script.

### .NET
.NET testing is not integrated in buck yet, you might need to set up .NET testing environment. We have a script which to launch C# test on macOS, `csharp/tests/Facebook.Yoga/test_macos.sh`.

## Code style
For the main C implementation of Yoga clang-format is used to ensure a consistent code style. Please run `bash format.sh` before submitting a pull request. For other languages just try to follow the current code style.

## Benchmarks
Benchmarks are located in `benchmarks/YGBenchmark.c` and can be run with `buck run //benchmarks:benchmarks`. If you think your change has affected performance please run this before and after your change to validate that nothing has regressed. Benchmarks are run on every commit in CI.
